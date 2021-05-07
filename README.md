# Overview
This is an MVC project that uses a simplified onion architecture. I threw together a basic UI to allow all of the API calls to be made as REST calls.

# Explanations
 - JSON file name/path can be configured in appsettings.json
 - A webservice is set up as an "Area" in the MVC app and just uses a standard controller. 
 - The service layer right now just acts as a sort of facade above the data layer, it would be responsible for business logic and aggregating/merging objects after retrieval. 
 - A basic JSONContext class that is responsible for opening and saving the JSON file so I could create some example unit tests without bleeding into integration tests. Depending on the database/architecture, I'd likely use a framework or Library rather than re-invent the wheel.
 - I chose to write example unit tests for the repository layer, since right now, it's the only one with any logic or real responsibility. I would write unit tests all the way up the stack if this were to be a real API/application.
 - Used xUnit for testing.
 