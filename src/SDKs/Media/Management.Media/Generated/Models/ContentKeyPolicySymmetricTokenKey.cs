// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Media.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Specifies a symmetric key for token validation.
    /// </summary>
    [Newtonsoft.Json.JsonObject("#Microsoft.Media.ContentKeyPolicySymmetricTokenKey")]
    public partial class ContentKeyPolicySymmetricTokenKey : ContentKeyPolicyRestrictionTokenKey
    {
        /// <summary>
        /// Initializes a new instance of the ContentKeyPolicySymmetricTokenKey
        /// class.
        /// </summary>
        public ContentKeyPolicySymmetricTokenKey()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ContentKeyPolicySymmetricTokenKey
        /// class.
        /// </summary>
        /// <param name="keyValue">The key value of the key</param>
        public ContentKeyPolicySymmetricTokenKey(byte[] keyValue)
        {
            KeyValue = keyValue;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the key value of the key
        /// </summary>
        [JsonProperty(PropertyName = "keyValue")]
        public byte[] KeyValue { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (KeyValue == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "KeyValue");
            }
        }
    }
}
