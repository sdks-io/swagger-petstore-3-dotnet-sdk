// <copyright file="PetController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstoreOpenAPI30.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using SwaggerPetstoreOpenAPI30.Standard;
    using SwaggerPetstoreOpenAPI30.Standard.Authentication;
    using SwaggerPetstoreOpenAPI30.Standard.Exceptions;
    using SwaggerPetstoreOpenAPI30.Standard.Http.Client;
    using SwaggerPetstoreOpenAPI30.Standard.Utilities;
    using System.Net.Http;

    /// <summary>
    /// PetController.
    /// </summary>
    public class PetController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PetController"/> class.
        /// </summary>
        internal PetController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Update an existing pet by Id.
        /// </summary>
        /// <param name="name">Required parameter: Example: .</param>
        /// <param name="photoUrls">Required parameter: Example: .</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="category">Optional parameter: Example: .</param>
        /// <param name="tags">Optional parameter: Example: .</param>
        /// <param name="petStatus">Optional parameter: pet status in the store.</param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public Models.Pet UpdatePet(
                string name,
                List<string> photoUrls,
                long? id = null,
                Models.Category category = null,
                List<Models.Tag> tags = null,
                Models.PetStatusEnum? petStatus = null)
            => CoreHelper.RunTask(UpdatePetAsync(name, photoUrls, id, category, tags, petStatus));

        /// <summary>
        /// Update an existing pet by Id.
        /// </summary>
        /// <param name="name">Required parameter: Example: .</param>
        /// <param name="photoUrls">Required parameter: Example: .</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="category">Optional parameter: Example: .</param>
        /// <param name="tags">Optional parameter: Example: .</param>
        /// <param name="petStatus">Optional parameter: pet status in the store.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public async Task<Models.Pet> UpdatePetAsync(
                string name,
                List<string> photoUrls,
                long? id = null,
                Models.Category category = null,
                List<Models.Tag> tags = null,
                Models.PetStatusEnum? petStatus = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.Pet>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/pet")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Header(_header => _header.Setup("Content-Type", "application/x-www-form-urlencoded"))
                      .Form(_form => _form.Setup("name", name))
                      .Form(_form => _form.Setup("photoUrls", photoUrls))
                      .Form(_form => _form.Setup("id", id))
                      .Form(_form => _form.Setup("category", category))
                      .Form(_form => _form.Setup("tags", tags))
                      .Form(_form => _form.Setup("petStatus", (petStatus.HasValue) ? ApiHelper.JsonSerialize(petStatus.Value).Trim('\"') : null))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid ID supplied", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("Pet not found", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("405", CreateErrorCase("Validation exception", (_reason, _context) => new ApiException(_reason, _context)))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.Pet>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Add a new pet to the store.
        /// </summary>
        /// <param name="name">Required parameter: Example: .</param>
        /// <param name="photoUrls">Required parameter: Example: .</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="category">Optional parameter: Example: .</param>
        /// <param name="tags">Optional parameter: Example: .</param>
        /// <param name="petStatus">Optional parameter: pet status in the store.</param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public Models.Pet AddPet(
                string name,
                List<string> photoUrls,
                long? id = null,
                Models.Category category = null,
                List<Models.Tag> tags = null,
                Models.PetStatusEnum? petStatus = null)
            => CoreHelper.RunTask(AddPetAsync(name, photoUrls, id, category, tags, petStatus));

        /// <summary>
        /// Add a new pet to the store.
        /// </summary>
        /// <param name="name">Required parameter: Example: .</param>
        /// <param name="photoUrls">Required parameter: Example: .</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="category">Optional parameter: Example: .</param>
        /// <param name="tags">Optional parameter: Example: .</param>
        /// <param name="petStatus">Optional parameter: pet status in the store.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public async Task<Models.Pet> AddPetAsync(
                string name,
                List<string> photoUrls,
                long? id = null,
                Models.Category category = null,
                List<Models.Tag> tags = null,
                Models.PetStatusEnum? petStatus = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.Pet>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/pet")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Header(_header => _header.Setup("Content-Type", "application/x-www-form-urlencoded"))
                      .Form(_form => _form.Setup("name", name))
                      .Form(_form => _form.Setup("photoUrls", photoUrls))
                      .Form(_form => _form.Setup("id", id))
                      .Form(_form => _form.Setup("category", category))
                      .Form(_form => _form.Setup("tags", tags))
                      .Form(_form => _form.Setup("petStatus", (petStatus.HasValue) ? ApiHelper.JsonSerialize(petStatus.Value).Trim('\"') : null))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("405", CreateErrorCase("Invalid input", (_reason, _context) => new ApiException(_reason, _context)))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.Pet>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Multiple status values can be provided with comma separated strings.
        /// </summary>
        /// <param name="status">Optional parameter: Status values that need to be considered for filter.</param>
        /// <returns>Returns the List of Models.Pet response from the API call.</returns>
        public List<Models.Pet> FindPetsByStatus(
                Models.StatusEnum? status = Models.StatusEnum.Available)
            => CoreHelper.RunTask(FindPetsByStatusAsync(status));

        /// <summary>
        /// Multiple status values can be provided with comma separated strings.
        /// </summary>
        /// <param name="status">Optional parameter: Status values that need to be considered for filter.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.Pet response from the API call.</returns>
        public async Task<List<Models.Pet>> FindPetsByStatusAsync(
                Models.StatusEnum? status = Models.StatusEnum.Available,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<Models.Pet>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/pet/findByStatus")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("status", (status.HasValue) ? ApiHelper.JsonSerialize(status.Value).Trim('\"') : "available"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid status value", (_reason, _context) => new ApiException(_reason, _context)))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<List<Models.Pet>>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.
        /// </summary>
        /// <param name="tags">Optional parameter: Tags to filter by.</param>
        /// <returns>Returns the List of Models.Pet response from the API call.</returns>
        public List<Models.Pet> FindPetsByTags(
                List<string> tags = null)
            => CoreHelper.RunTask(FindPetsByTagsAsync(tags));

        /// <summary>
        /// Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.
        /// </summary>
        /// <param name="tags">Optional parameter: Tags to filter by.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.Pet response from the API call.</returns>
        public async Task<List<Models.Pet>> FindPetsByTagsAsync(
                List<string> tags = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<Models.Pet>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/pet/findByTags")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("tags", tags))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid tag value", (_reason, _context) => new ApiException(_reason, _context)))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<List<Models.Pet>>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Returns a single pet.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet to return.</param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public Models.Pet GetPetById(
                long petId)
            => CoreHelper.RunTask(GetPetByIdAsync(petId));

        /// <summary>
        /// Returns a single pet.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet to return.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public async Task<Models.Pet> GetPetByIdAsync(
                long petId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.Pet>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/pet/{petId}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("petId", petId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid ID supplied", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("Pet not found", (_reason, _context) => new ApiException(_reason, _context)))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.Pet>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Updates a pet in the store with form data.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet that needs to be updated.</param>
        /// <param name="name">Optional parameter: Name of pet that needs to be updated.</param>
        /// <param name="status">Optional parameter: Status of pet that needs to be updated.</param>
        public void UpdatePetWithForm(
                long petId,
                string name = null,
                string status = null)
            => CoreHelper.RunVoidTask(UpdatePetWithFormAsync(petId, name, status));

        /// <summary>
        /// Updates a pet in the store with form data.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet that needs to be updated.</param>
        /// <param name="name">Optional parameter: Name of pet that needs to be updated.</param>
        /// <param name="status">Optional parameter: Status of pet that needs to be updated.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task UpdatePetWithFormAsync(
                long petId,
                string name = null,
                string status = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/pet/{petId}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("petId", petId))
                      .Query(_query => _query.Setup("name", name))
                      .Query(_query => _query.Setup("status", status))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("405", CreateErrorCase("Invalid input", (_reason, _context) => new ApiException(_reason, _context)))
)
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// delete a pet.
        /// </summary>
        /// <param name="petId">Required parameter: Pet id to delete.</param>
        /// <param name="apiKey">Optional parameter: Example: .</param>
        public void DeletePet(
                long petId,
                string apiKey = null)
            => CoreHelper.RunVoidTask(DeletePetAsync(petId, apiKey));

        /// <summary>
        /// delete a pet.
        /// </summary>
        /// <param name="petId">Required parameter: Pet id to delete.</param>
        /// <param name="apiKey">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DeletePetAsync(
                long petId,
                string apiKey = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/pet/{petId}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("petId", petId))
                      .Header(_header => _header.Setup("api_key", apiKey))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid pet value", (_reason, _context) => new ApiException(_reason, _context)))
)
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// uploads an image.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet to update.</param>
        /// <param name="additionalMetadata">Optional parameter: Additional Metadata.</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.PetImage response from the API call.</returns>
        public Models.PetImage UploadFile(
                long petId,
                string additionalMetadata = null,
                FileStreamInfo body = null)
            => CoreHelper.RunTask(UploadFileAsync(petId, additionalMetadata, body));

        /// <summary>
        /// uploads an image.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet to update.</param>
        /// <param name="additionalMetadata">Optional parameter: Additional Metadata.</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.PetImage response from the API call.</returns>
        public async Task<Models.PetImage> UploadFileAsync(
                long petId,
                string additionalMetadata = null,
                FileStreamInfo body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PetImage>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/pet/{petId}/uploadImage")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("petId", petId))
                      .Header(_header => _header.Setup("Content-Type", "application/octet-stream"))
                      .Query(_query => _query.Setup("additionalMetadata", additionalMetadata))
                      .Form(_form => _form.Setup("body", body))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.PetImage>(_response)))
              .ExecuteAsync(cancellationToken);
    }
}