# Reset Zoom

[![Build status](https://ci.appveyor.com/api/projects/status/w2iwr8a2l1yar4w0?svg=true)](https://ci.appveyor.com/project/madskristensen/resetzoom)

Download this extension from the [Marketplace](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.ResetZoom)
or get the [CI build](http://vsixgallery.com/extension/0a987da3-4577-4eec-aaa9-a4c2cdd5d22b/).

---------------------------------------

See the [change log](CHANGELOG.md) for changes and road map.

Zooming in the Visual Studio editor is easy using the mouse wheel or trackpad. However, there is no command in Visual Studio for resetting the zoom level back to 100%. That's what this extension provides.

![Zoom control](art/zoom-control.png)

## Reset zoom to 100%
By default, the keyboard shortcut is `Ctrl+0,Ctrl+0` but can be changed to be whatever you like. 

Go to **Tools -> Options -> Environment -> Keyboard** and look for the command `View.ZoomReset` to change the keyboard shortcut.

### Custom zoom default
You can set what the default zoom level should be in **Tools -> Options -> Environment -> Reset Zoom**.

![Options](art/options.png)

## Contribute
Check out the [contribution guidelines](.github/CONTRIBUTING.md)
if you want to contribute to this project.

For cloning and building this project yourself, make sure
to install the
[Extensibility Tools 2015](https://visualstudiogallery.msdn.microsoft.com/ab39a092-1343-46e2-b0f1-6a3f91155aa6)
extension for Visual Studio which enables some features
used by this project.

## License
[Apache 2.0](LICENSE)