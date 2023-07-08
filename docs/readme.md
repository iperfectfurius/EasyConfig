## EasyConfig

#### This library allow to simplify a config file to save and load on start of the program super easy.

### How to Use

* Import or install the library

##### Create a config file with defaults settings
```c# 
//Declare the Config Class at start of the application to read memory config before the app is loaded.
	Config config = new(); //This will create an .ini file in your Enviroments application folder (%appdata% on Windows)	
```
##### Optional Parameters

Config(string FolderName,string ConfigFileName,Dictionary<(string, string), string> DefaultConfig)

** Default Config only is setted if config file dosn't exist or ResetConfig() is called
##### How to save or retrieve any configuration

```c#
//Continuing same example as before
//We will use ConfigData member to save and retrieve any configuration
	config.ConfigData["section"]["configurationName"] = "This is a test"

/*
	The example before will save a .ini with this structure
	Config.ini:
		|
		[section]
		configurationName=This is a test
*/
		
		
		
```
		

## Dependencies

 * Ini-parser by [rickyah](https://www.nuget.org/profiles/rickyah)
