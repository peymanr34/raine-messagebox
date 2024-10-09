namespace Raine.MessageBox
{
    using System;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// The <see cref="MessageBoxBuilder"/> class.
    /// </summary>
    public class MessageBoxBuilder
    {
        private readonly StringBuilder _builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxBuilder"/> class.
        /// </summary>
        public MessageBoxBuilder()
        {
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxBuilder"/> class using the specified <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">An instance of <see cref="StringBuilder"/> class to build the text of the message box.</param>
        public MessageBoxBuilder(StringBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        /// <summary>
        /// Gets the text to display in the title bar of the message box.
        /// </summary>
        public string? Caption { get; private set; }

        /// <summary>
        /// Gets the value that specifies which icon to display in the message box.
        /// </summary>
        public MessageBoxIcon Icon { get; private set; }

        /// <summary>
        /// Gets the value that specifies which buttons to display in the message box.
        /// </summary>
        public MessageBoxButtons Buttons { get; private set; }

        /// <summary>
        /// Gets the value that specifies the default button for the message box.
        /// </summary>
        public MessageBoxDefaultButton DefaultButton { get; private set; }

        /// <summary>
        /// Gets the value that specifies which display and association options will be used for the message box.
        /// </summary>
        public MessageBoxOptions Options { get; private set; }

        /// <summary>
        /// Sets the text to display in the message box.
        /// </summary>
        /// <param name="value">The text to display in the message box.</param>
        /// <returns>A reference to this instance after setting the value.</returns>
        public MessageBoxBuilder WithText(string? value)
        {
            _builder.Clear();
            _builder.Append(value);
            return this;
        }

        /// <summary>
        /// Appends a copy of the specified string to the current text.
        /// </summary>
        /// <param name="value">The string to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public MessageBoxBuilder WithAppend(string? value)
        {
            _builder.Append(value);
            return this;
        }

        /// <summary>
        /// Appends a copy of the specified string followed by the default line terminator to the end of the current text.
        /// </summary>
        /// <param name="value">The string to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public MessageBoxBuilder WithAppendLine(string? value = null)
        {
            _builder.AppendLine(value);
            return this;
        }

        /// <summary>
        /// Sets the text to display in the title bar of the message box.
        /// </summary>
        /// <param name="value">The text to display in the title bar of the message box.</param>
        /// <returns>A reference to this instance after setting the value.</returns>
        public MessageBoxBuilder WithCaption(string? value)
        {
            Caption = value;
            return this;
        }

        /// <summary>
        /// Sets the value that specifies which buttons to display in the message box.
        /// </summary>
        /// <param name="buttons">One of the <see cref="MessageBoxButtons"/> values that specifies which buttons to display in the message box.</param>
        /// <returns>A reference to this instance after setting the value.</returns>
        public MessageBoxBuilder WithButtons(MessageBoxButtons buttons)
        {
            Buttons = buttons;
            return this;
        }

        /// <summary>
        /// Sets the value that specifies which icon to display in the message box.
        /// </summary>
        /// <param name="icon">One of the <see cref="MessageBoxIcon"/> values that specifies which icon to display in the message box.</param>
        /// <returns>A reference to this instance after setting the value.</returns>
        public MessageBoxBuilder WithIcon(MessageBoxIcon icon)
        {
            Icon = icon;
            return this;
        }

        /// <summary>
        /// Sets the value that specifies the default button for the message box.
        /// </summary>
        /// <param name="defaultButton">One of the <see cref="MessageBoxDefaultButton"/> values that specifies the default button for the message box.</param>
        /// <returns>A reference to this instance after setting the value.</returns>
        public MessageBoxBuilder WithDefaultButton(MessageBoxDefaultButton defaultButton)
        {
            DefaultButton = defaultButton;
            return this;
        }

        /// <summary>
        /// Sets the value that specifies which display and association options will be used for the message box.
        /// </summary>
        /// <param name="options">One of the <see cref="MessageBoxOptions"/> values that specifies which display and association options will be used for the message box.</param>
        /// <returns>A reference to this instance after setting the value.</returns>
        public MessageBoxBuilder WithOptions(MessageBoxOptions options)
        {
            Options = options;
            return this;
        }

        /// <summary>
        /// Displays the message box with the specified options.
        /// </summary>
        /// <returns>One of the <see cref="DialogResult"/> values.</returns>
        public DialogResult Show()
        {
            return MessageBox.Show(_builder.ToString(), Caption, Buttons, Icon, DefaultButton, Options);
        }

        /// <summary>
        /// Displays the message box with the specified options and owner.
        /// </summary>
        /// <param name="owner">An implementation of <see cref="IWin32Window"/> that will own the modal dialog box.</param>
        /// <returns>One of the <see cref="DialogResult"/> values.</returns>
        public DialogResult Show(IWin32Window owner)
        {
            return MessageBox.Show(owner, _builder.ToString(), Caption, Buttons, Icon, DefaultButton, Options);
        }
    }
}
