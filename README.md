BooksApi

Assumptions:
the custom 400 responce has an array of objects and nothing else, the default ApiController bad request has a bit more details. 
I deceided to follow the spec exatcly, so I changed the default to only provide a list of errors.

Changes I would make:
I would change the root parameters on the api controller to include a version number if this was a produciton api