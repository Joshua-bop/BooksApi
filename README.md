BooksApi

Assumptions:
the custom 400 responce has an array of objects and nothing else, the default ApiController bad request has a bit more details. 
I deceided to follow the spec exatcly, so I changed the default to only provide a list of errors.

Changes I would make:
I would change the root parameters on the api controller to include a version number if this was a produciton api

given more time, I would write Logging class, to handle logging errors from the API, and also implement a global error handler, in the action filter pipeline.

move out the DI resolution code from Program.cs into its own class to handle it, keeps the Program.cs looking cleaner.