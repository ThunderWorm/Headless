﻿namespace Headless
{
    using System;
    using System.Net;
    using System.Xml.XPath;

    /// <summary>
    ///     The <see cref="HtmlForm" />
    ///     class exposes all the form fields for a form tag.
    /// </summary>
    [SupportedTag("form")]
    public class HtmlForm : HtmlElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlForm"/> class.
        /// </summary>
        /// <param name="page">
        /// The owning page.
        /// </param>
        /// <param name="node">
        /// The node.
        /// </param>
        public HtmlForm(IHtmlPage page, IXPathNavigable node) : base(page, node)
        {
        }

        /// <summary>
        /// Submits the specified form.
        /// </summary>
        /// <param name="sourceButton">
        /// The source button.
        /// </param>
        /// <returns>
        /// A <see cref="IPage"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="sourceButton"/> parameter is <c>null</c>.
        /// </exception>
        public IPage Submit(HtmlButton sourceButton)
        {
            if (sourceButton == null)
            {
                throw new ArgumentNullException("sourceButton");
            }

            var parameters = this.BuildPostParameters(sourceButton);

            return Page.Browser.PostTo(parameters, PostLocation, HttpStatusCode.OK);
        }

        /// <summary>
        ///     Gets the action of the form.
        /// </summary>
        /// <value>
        ///     The action of the form.
        /// </value>
        public string Action
        {
            get
            {
                return GetAttributeValue("action");
            }
        }

        /// <summary>
        ///     Gets the method of the form.
        /// </summary>
        /// <value>
        ///     The method of the form.
        /// </value>
        public string Method
        {
            get
            {
                return GetAttributeValue("method");
            }
        }

        /// <summary>
        ///     Gets the name of the form.
        /// </summary>
        /// <value>
        ///     The name of the form.
        /// </value>
        public string Name
        {
            get
            {
                return GetAttributeValue("name");
            }
        }

        /// <summary>
        ///     Gets the post location.
        /// </summary>
        /// <value>
        ///     The post location.
        /// </value>
        public Uri PostLocation
        {
            get
            {
                Uri location;
                var action = Action;

                if (string.IsNullOrWhiteSpace(action))
                {
                    // There is no action so we are posting to the current location
                    location = Page.Location;
                }
                else
                {
                    location = new Uri(action, UriKind.RelativeOrAbsolute);

                    if (location.IsAbsoluteUri == false)
                    {
                        location = new Uri(Page.Location, location);
                    }
                }

                return location;
            }
        }

        /// <summary>
        ///     Gets the target of the form.
        /// </summary>
        /// <value>
        ///     The target of the form.
        /// </value>
        public string Target
        {
            get
            {
                return GetAttributeValue("target");
            }
        }
    }
}