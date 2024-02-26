# PharmacyController.cs

This file contains the `PharmaciesController` class, which is a part of the Pharmacy API. It is responsible for handling
HTTP requests related to pharmacies.

## Methods

### FindPharmacies

This is a `GET` method that retrieves all pharmacies. It does not require any parameters.

### FindPharmacyById

This is a `GET` method that retrieves a specific pharmacy by its ID. It requires the ID of the pharmacy as a parameter.

### CreatePharmacy

This is a `POST` method that creates a new pharmacy. It requires a `NewPharmacy` object as a parameter in the request
body.

### UpdatePharmacy

This is a `PUT` method that updates an existing pharmacy. It requires the ID of the pharmacy and a `PharmacyUpdates`
object as parameters.

## Usage

To use these endpoints, send a HTTP request to the `/Pharmacies` route followed by the method name (if applicable).
For example, to get a specific pharmacy, send a `GET` request to `/Pharmacies/{id}` where `{id}` is the ID of the
pharmacy.

Please note that all methods are asynchronous and may require a `CancellationToken` as a parameter.

To check the health of the API, send a `GET` request to `/Pharmacies/Health`.

To migrate data in the seeds file:
Navigate to the Pharmacy.Api directory

```bash
#1. Create the migration
dotnet ef migrations add InitialCreate
#2. Update the database
dotnet ef database update
```

To run the API, navigate to the Pharmacy.Api directory and run the following command:

```bash
dotnet run
```

To run the tests, navigate to the Pharmacy.Api.Tests directory and run the following command:

```bash
dotnet test
```

To:

1. Create Tables
2. Insert Data
3. Fetch Data
4. Report Data

Please Navigate [Database](./Pharmacy.Business/Database)
