# Raine.MessageBox
A fluent interface for the [System.Windows.Forms.MessageBox][msgbox-docs] class.

[![NuGet Version][nuget-shield]][nuget]
[![NuGet Downloads][nuget-shield-dl]][nuget]

## Installation
You can install this package via the `Package Manager Console` in Visual Studio.

```powershell
Install-Package Raine.MessageBox -PreRelease
```

> [!NOTE]
> This package requires **.NET Framework 4.8** or **.NET 6.0+**

## Usage
The following example shows how to build a simple message box.

```csharp
// using Raine.MessageBox;

DialogResult result = new MessageBoxBuilder()
    .WithText("Would you like to exit?")
    .WithCaption("Are you sure?")
    .WithButtons(MessageBoxButtons.YesNo)
    .WithIcon(MessageBoxIcon.Question)
    .Show();
```

You can do the same in Visual Basic.

```vbnet
' Imports Raine.MessageBox

Dim Result As DialogResult = New MessageBoxBuilder().
    WithText("Would you like to exit?").
    WithCaption("Are you sure?").
    WithButtons(MessageBoxButtons.YesNo).
    WithIcon(MessageBoxIcon.Question).
    Show()
```

Since we're using a `StringBuilder`, we have a `WithAppendLine` method.

```csharp
// using Raine.MessageBox;

DialogResult result = new MessageBoxBuilder()
    .WithAppendLine("Would you like to exit?")
    .WithAppendLine("Any unsaved progress will be lost.")
    .WithAppendLine("Please save your work before continue.")
    .WithCaption("Are you sure?")
    .WithButtons(MessageBoxButtons.YesNo)
    .WithIcon(MessageBoxIcon.Question)
    .Show();
```

You can also have access to the other message box options.

```csharp
// using Raine.MessageBox;

DialogResult result = new MessageBoxBuilder()
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

## License
This project is licensed under the [MIT License](LICENSE).

[msgbox-docs]: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox

[nuget]: https://www.nuget.org/packages/Raine.MessageBox
[nuget-shield]: https://img.shields.io/nuget/v/Raine.MessageBox.svg?label=NuGet
[nuget-shield-dl]: https://img.shields.io/nuget/dt/Raine.MessageBox?label=Downloads&color=red