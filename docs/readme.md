## EasyConfig

#### This library allows you to simplify a config file for super easy saving and loading at the start of the application.

### How to Use

* Import or install the library

##### Create a config file with defaults settings
```c# 
// Declare the Config Class at start of the application to read memory config before the app is loaded.
	Config config = new(); //This will create an .ini file in your Enviroments application folder (%appdata% on Windows) and save it any time the app is closed

```
You can save manually if `SaveConfig()` is called.

##### Optional Parameters

* string FolderName
* string ConfigFileName
* Dictionary<(string, string), string>
* bool AutoSave

Config(string FolderName,string ConfigFileName,Dictionary<(string, string), string> DefaultConfig,bool AutoSave)

**The default config is only set if the config file doesn't exist or ResetConfig() is called.**
##### How to save or retrieve any configuration

```c#
//Continuing same example as before.
//We will use ConfigData member to save and retrieve any configuration.
	config.ConfigData["section"]["configurationName"] = "This is a test"

/*
	The previous example will save a .ini file with this structure.
	Config.ini:
		|
		[section]
		configurationName=This is a test
*/
```

#### Other Methods

* `DeleteFileConfig(Config ConfigFile)` (Static)
* `OpenConfig()` Open current config file.
* `ResetConfig()` Reset the memory config.
		
### Notes

**If you want to use multiple configurations on the same project you will need to specify a name for each configuration you need.**

## Dependencies

 * Ini-parser by [rickyah](https://www.nuget.org/profiles/rickyah)
