// Fill out your copyright notice in the Description page of Project Settings.

using System.IO;
using UnrealBuildTool;

public class TagLib2Library : ModuleRules
{
    public TagLib2Library(ReadOnlyTargetRules Target) : base(Target)
    {
        Type = ModuleType.External;

        PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "include"));

        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            // Add the import library
            PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "x64", "Release", "tag.lib"));

            // Delay-load the DLL, so we can load it from the right place first
            PublicDelayLoadDLLs.Add("tag.dll");

            // Ensure that the DLL is staged along with the executable
            RuntimeDependencies.Add("$(PluginDir)/Binaries/ThirdParty/TagLib2Library/Win64/tag.dll");
        }
        else if (Target.Platform == UnrealTargetPlatform.Mac)
        {
            PublicDelayLoadDLLs.Add(Path.Combine(ModuleDirectory, "Mac", "Release", "tag.dylib"));
            RuntimeDependencies.Add("$(PluginDir)/Source/ThirdParty/TagLib2Library/Mac/Release/tag.dylib");
        }
        else if (Target.Platform == UnrealTargetPlatform.Linux)
        {
            string ExampleSoPath = Path.Combine("$(PluginDir)", "Binaries", "ThirdParty", "TagLib2Library", "Linux", "x86_64-unknown-linux-gnu", "tag.so");
            PublicAdditionalLibraries.Add(ExampleSoPath);
            PublicDelayLoadDLLs.Add(ExampleSoPath);
            RuntimeDependencies.Add(ExampleSoPath);
        }
    }
}
