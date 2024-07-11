# FlightManagementSystem

## Overview

FlightManagementSystem is a project built using Clean Architecture and Domain-Driven Design (DDD) principles.
The project uses PostgreSQL as its database and xUnit, Moq, and FluentAssertions for testing.

## Core Business Logic

The primary business logic for the FlightManagementSystem involves three main steps:
1. **Get Flight from DB**: Retrieve the flight details from the database.
2. **Perform Check-In Business Logic**: Execute the necessary logic to check in a passenger.
3. **Update Flight After Check-In**: Update the flight details in the database post check-in.

## Notes

To handle potential concurrency issues, the system uses row versioning (optimistic concurrency).
This ensures that when two passengers attempt to check-in simultaneously, and there is only one seat left, the system will handle this gracefully by:

- Detecting any updates made to the flight between the retrieval (step 1) and the update attempt (step 3).
- Throwing a `DbConcurrencyException` if a conflict is detected.
- Retrying the check-in process within a retry block, where the validation step (step 2) will now fail due to the seat unavailability, resulting in a `DomainException`.