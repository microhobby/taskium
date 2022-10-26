/*
 * taskium.server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using FileParameter = TaskiumRestAPI.Client.FileParameter;
using OpenAPIDateConverter = TaskiumRestAPI.Client.OpenAPIDateConverter;

namespace TaskiumRestAPI.Model
{
    /// <summary>
    /// Task
    /// </summary>
    [DataContract(Name = "Task")]
    public partial class Task : IEquatable<Task>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Task" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="taskLabel">taskLabel.</param>
        /// <param name="description">description.</param>
        /// <param name="repo">repo.</param>
        /// <param name="branch">branch.</param>
        /// <param name="stdErr">stdErr.</param>
        /// <param name="stdOut">stdOut.</param>
        /// <param name="isStarted">isStarted.</param>
        /// <param name="isComplete">isComplete.</param>
        /// <param name="returnCode">returnCode.</param>
        public Task(int id = default(int), string name = default(string), string taskLabel = default(string), string description = default(string), string repo = default(string), string branch = default(string), string stdErr = default(string), string stdOut = default(string), bool isStarted = default(bool), bool isComplete = default(bool), int returnCode = default(int))
        {
            this.Id = id;
            this.Name = name;
            this.TaskLabel = taskLabel;
            this.Description = description;
            this.Repo = repo;
            this.Branch = branch;
            this.StdErr = stdErr;
            this.StdOut = stdOut;
            this.IsStarted = isStarted;
            this.IsComplete = isComplete;
            this.ReturnCode = returnCode;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets TaskLabel
        /// </summary>
        [DataMember(Name = "taskLabel", EmitDefaultValue = true)]
        public string TaskLabel { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Repo
        /// </summary>
        [DataMember(Name = "repo", EmitDefaultValue = true)]
        public string Repo { get; set; }

        /// <summary>
        /// Gets or Sets Branch
        /// </summary>
        [DataMember(Name = "branch", EmitDefaultValue = true)]
        public string Branch { get; set; }

        /// <summary>
        /// Gets or Sets StdErr
        /// </summary>
        [DataMember(Name = "stdErr", EmitDefaultValue = true)]
        public string StdErr { get; set; }

        /// <summary>
        /// Gets or Sets StdOut
        /// </summary>
        [DataMember(Name = "stdOut", EmitDefaultValue = true)]
        public string StdOut { get; set; }

        /// <summary>
        /// Gets or Sets IsStarted
        /// </summary>
        [DataMember(Name = "isStarted", EmitDefaultValue = true)]
        public bool IsStarted { get; set; }

        /// <summary>
        /// Gets or Sets IsComplete
        /// </summary>
        [DataMember(Name = "isComplete", EmitDefaultValue = true)]
        public bool IsComplete { get; set; }

        /// <summary>
        /// Gets or Sets ReturnCode
        /// </summary>
        [DataMember(Name = "returnCode", EmitDefaultValue = false)]
        public int ReturnCode { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Task {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  TaskLabel: ").Append(TaskLabel).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Repo: ").Append(Repo).Append("\n");
            sb.Append("  Branch: ").Append(Branch).Append("\n");
            sb.Append("  StdErr: ").Append(StdErr).Append("\n");
            sb.Append("  StdOut: ").Append(StdOut).Append("\n");
            sb.Append("  IsStarted: ").Append(IsStarted).Append("\n");
            sb.Append("  IsComplete: ").Append(IsComplete).Append("\n");
            sb.Append("  ReturnCode: ").Append(ReturnCode).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Task);
        }

        /// <summary>
        /// Returns true if Task instances are equal
        /// </summary>
        /// <param name="input">Instance of Task to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Task input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.TaskLabel == input.TaskLabel ||
                    (this.TaskLabel != null &&
                    this.TaskLabel.Equals(input.TaskLabel))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Repo == input.Repo ||
                    (this.Repo != null &&
                    this.Repo.Equals(input.Repo))
                ) && 
                (
                    this.Branch == input.Branch ||
                    (this.Branch != null &&
                    this.Branch.Equals(input.Branch))
                ) && 
                (
                    this.StdErr == input.StdErr ||
                    (this.StdErr != null &&
                    this.StdErr.Equals(input.StdErr))
                ) && 
                (
                    this.StdOut == input.StdOut ||
                    (this.StdOut != null &&
                    this.StdOut.Equals(input.StdOut))
                ) && 
                (
                    this.IsStarted == input.IsStarted ||
                    this.IsStarted.Equals(input.IsStarted)
                ) && 
                (
                    this.IsComplete == input.IsComplete ||
                    this.IsComplete.Equals(input.IsComplete)
                ) && 
                (
                    this.ReturnCode == input.ReturnCode ||
                    this.ReturnCode.Equals(input.ReturnCode)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.TaskLabel != null)
                {
                    hashCode = (hashCode * 59) + this.TaskLabel.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                if (this.Repo != null)
                {
                    hashCode = (hashCode * 59) + this.Repo.GetHashCode();
                }
                if (this.Branch != null)
                {
                    hashCode = (hashCode * 59) + this.Branch.GetHashCode();
                }
                if (this.StdErr != null)
                {
                    hashCode = (hashCode * 59) + this.StdErr.GetHashCode();
                }
                if (this.StdOut != null)
                {
                    hashCode = (hashCode * 59) + this.StdOut.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IsStarted.GetHashCode();
                hashCode = (hashCode * 59) + this.IsComplete.GetHashCode();
                hashCode = (hashCode * 59) + this.ReturnCode.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
