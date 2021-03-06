﻿namespace Headless
{
    using System;
    using System.Xml.XPath;
    using Headless.Activation;

    /// <summary>
    ///     The <see cref="HtmlInput" />
    ///     class is used to represent a HTML input element.
    /// </summary>
    /// <remarks>This class supports HTML5 input fields and textarea elements.</remarks>
    [SupportedTag("input", "type", "color")]
    [SupportedTag("input", "type", "date")]
    [SupportedTag("input", "type", "datetime")]
    [SupportedTag("input", "type", "datetime-local")]
    [SupportedTag("input", "type", "email")]
    [SupportedTag("input", "type", "hidden")]
    [SupportedTag("input", "type", "month")]
    [SupportedTag("input", "type", "number")]
    [SupportedTag("input", "type", "password")]
    [SupportedTag("input", "type", "range")]
    [SupportedTag("input", "type", "search")]
    [SupportedTag("input", "type", "tel")]
    [SupportedTag("input", "type", "text")]
    [SupportedTag("input", "type", "time")]
    [SupportedTag("input", "type", "url")]
    [SupportedTag("input", "type", "week")]
    [SupportedTag("textarea")]
    public class HtmlInput : HtmlFormElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlInput"/> class.
        /// </summary>
        /// <param name="page">
        /// The owning page.
        /// </param>
        /// <param name="node">
        /// The node.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="page"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="node"/> parameter is <c>null</c>.
        /// </exception>
        public HtmlInput(IHtmlPage page, IXPathNavigable node) : base(page, node)
        {
        }

        /// <inheritdoc />
        public override string Value
        {
            get
            {
                var navigator = Node.GetNavigator();

                if (navigator.Name.Equals("textarea", StringComparison.OrdinalIgnoreCase))
                {
                    // Return the content of the node
                    var value = navigator.InnerXml;

                    if (value.StartsWith(Environment.NewLine, StringComparison.OrdinalIgnoreCase))
                    {
                        // Textarea tags render with a new line that is not part of the value
                        return value.Substring(2);
                    }

                    return value;
                }

                return base.Value;
            }

            set
            {
                var navigator = Node.GetNavigator();

                if (navigator.Name.Equals("textarea", StringComparison.OrdinalIgnoreCase))
                {
                    // Return the content of the node
                    navigator.InnerXml = Environment.NewLine + value;
                }
                else
                {
                    base.Value = value;
                }
            }
        }
    }
}