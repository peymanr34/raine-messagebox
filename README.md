# Raine.MessageBox
A fluent interface for the [System.Windows.Forms.MessageBox][msgbox-docs] class.

[![Nuget Version][nuget-shield]][nuget]
[![Nuget Downloads][nuget-shield-dl]][nuget]

## Installing
You can install this package by entering the following command into your `Package Manager Console`:
```powershell
Install-Package Raine.MessageBox -PreRelease
```
*Note:* This package requires **.NET Framework 4.8** or **.NET 5.0+**.

## How to use
The following example shows how to build a simple message box:
```csharp
DialogResult result = new Raine.MessageBox.MessageBoxBuilder()
    .WithText("Would you like to exit?")
    .WithCaption("Are you sure?")
    .WithButtons(MessageBoxButtons.YesNo)
    .WithIcon(MessageBoxIcon.Question)
    .Show();
```
You can do the same in Visual Basic:
```vbnet
Dim Result As DialogResult = New Raine.MessageBox.MessageBoxBuilder().
    WithText("Would you like to exit?").
    WithCaption("Are you sure?").
    WithButtons(MessageBoxButtons.YesNo).
    WithIcon(MessageBoxIcon.Question).
    Show()
```
Alternatively, because we're using a `StringBuilder` under the hood, you can build the message box text like this:
```csharp
DialogResult result = new Raine.MessageBox.MessageBoxBuilder()
    .WithAppendLine("Would you like to exit?")
    .WithAppendLine("Any unsaved progress will be lost.")
    .WithAppendLine("Please save your work before continue.")
    .WithCaption("Are you sure?")
    .WithButtons(MessageBoxButtons.YesNo)
    .WithIcon(MessageBoxIcon.Question)
    .Show();
```
You can also have access to the other message box options:
```csharp
DialogResult result = new Raine.MessageBox.MessageBoxBuilder()
    .WithAppendLine("Would you like to exit?")
    .WithAppendLine("Any unsaved progress will be lost.")
    .WithAppendLine("Please save your work before continue.")
    .WithCaption("Are you sure?")
    .WithButtons(MessageBoxButtons.YesNo)
    .WithIcon(MessageBoxIcon.Question)
    .WithDefaultButton(MessageBoxDefaultButton.Button2)
    .WithOptions(MessageBoxOptions.RightAlign)
    .Show();
```
Have fun! 🎉

## License
This project is licensed under the [MIT License](LICENSE).

[msgbox-docs]: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox

[nuget]: https://www.nuget.org/packages/Raine.MessageBox
[nuget-shield]: https://img.shields.io/nuget/v/Raine.MessageBox.svg?label=Release
[nuget-shield-dl]: https://img.shields.io/nuget/dt/Raine.MessageBox?label=Downloads&color=red