// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.DataFactory.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// DatabricksSparkPython activity.
    /// </summary>
    [Newtonsoft.Json.JsonObject("DatabricksSparkPython")]
    [Rest.Serialization.JsonTransformation]
    public partial class DatabricksSparkPythonActivity : ExecutionActivity
    {
        /// <summary>
        /// Initializes a new instance of the DatabricksSparkPythonActivity
        /// class.
        /// </summary>
        public DatabricksSparkPythonActivity()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DatabricksSparkPythonActivity
        /// class.
        /// </summary>
        /// <param name="name">Activity name.</param>
        /// <param name="pythonFile">The URI of the Python file to be executed.
        /// DBFS paths are supported. Type: string (or Expression with
        /// resultType string).</param>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="description">Activity description.</param>
        /// <param name="dependsOn">Activity depends on condition.</param>
        /// <param name="userProperties">Activity user properties.</param>
        /// <param name="linkedServiceName">Linked service reference.</param>
        /// <param name="policy">Activity policy.</param>
        /// <param name="parameters">Command line parameters that will be
        /// passed to the Python file.</param>
        /// <param name="libraries">A list of libraries to be installed on the
        /// cluster that will execute the job.</param>
        public DatabricksSparkPythonActivity(string name, object pythonFile, IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), string description = default(string), IList<ActivityDependency> dependsOn = default(IList<ActivityDependency>), IDictionary<string, string> userProperties = default(IDictionary<string, string>), LinkedServiceReference linkedServiceName = default(LinkedServiceReference), ActivityPolicy policy = default(ActivityPolicy), IList<object> parameters = default(IList<object>), IList<IDictionary<string, object>> libraries = default(IList<IDictionary<string, object>>))
            : base(name, additionalProperties, description, dependsOn, userProperties, linkedServiceName, policy)
        {
            PythonFile = pythonFile;
            Parameters = parameters;
            Libraries = libraries;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the URI of the Python file to be executed. DBFS paths
        /// are supported. Type: string (or Expression with resultType string).
        /// </summary>
        [JsonProperty(PropertyName = "typeProperties.pythonFile")]
        public object PythonFile { get; set; }

        /// <summary>
        /// Gets or sets command line parameters that will be passed to the
        /// Python file.
        /// </summary>
        [JsonProperty(PropertyName = "typeProperties.parameters")]
        public IList<object> Parameters { get; set; }

        /// <summary>
        /// Gets or sets a list of libraries to be installed on the cluster
        /// that will execute the job.
        /// </summary>
        [JsonProperty(PropertyName = "typeProperties.libraries")]
        public IList<IDictionary<string, object>> Libraries { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
            if (PythonFile == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "PythonFile");
            }
        }
    }
}