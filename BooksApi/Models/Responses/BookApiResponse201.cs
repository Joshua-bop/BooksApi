/*
 * Books API
 *
 * API that manages a collection of books in a fictional store
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BooksApi.Models.Responses
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class BookApiResponse201
    { 
        /// <summary>
        /// Id of the created book.
        /// </summary>
        /// <value>Id of the created book.</value>

        [DataMember(Name="id")]
        public long? Id { get; set; }
    }
}
