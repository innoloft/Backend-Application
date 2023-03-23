# Instructions

Please stick to the following instructions on how to submit your application:

1. Read the **whole** README
2. Create a new repository on your Github Account. *Note: The repository has to be public.*
3. Add your solution **with all requirements** to your repository
4. Send a mail to [application@innoloft.com](mailto:application@innoloft.com) with following information:
   - Your Name
   - Link to **public** accessable repository on **GitHub**
   - How many hours it took to complete (roughly)

**Please do not spend much more than 6 hours for the whole task.** This is not a hard limitation but want to respect your time since we cannot hire every applicant. Also only start with the task if you think this is something you can do in the given time frame.

### Additional Information to submit a successful application

- Make sure that your repository is public
- Only an application with [all requirements](https://github.com/innoloft/Frontend-Application#technical-requirements) can be considered
- Provide setup process if required
- Copied structures or code from other applications will be completely ignored

Thank you very much and have fun with the challenge!

# Challenge

Develop a minified version of the Events module API based on wireframes. The API should provide endpoints for events CRUD.

It also should enable users to register for the the event.

### 1. List of current user’s events

![Event Listing](<assets/image_6.png>)

### 2. Creating & editing of event

![Event Creation](<assets/image_1.png>)

![Event Creation - Date Picking](<assets/image_2.png>)

### 3. Event info and participants registration

![Event Information](<assets/image_3.png>)

## Clarification

- You **do not** have to build the frontend. Only the API requests that would enable the frontend to work.
- Top navigation, menu on the left, etc. are not part of this task. This is only about the events module.
- Pagination should be added in GET all events to enable loading more events

# Technical Requirements

- Project
  - [ASP.NET Core web API application](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio). Prefer version 6.
- Database
  - Use SQLite or MySQL (**Do not use Microsoft SQL or SQL Express**). Please add setup instructions if necessary
  - Use EF Core ORM framework to work with database
- Tests project
  - At least one unit test should be written (even the simplest one)
- Project should be setup to run as a docker container - `Dockerfile` is required
- Attach user data
  - To get complete single event page response - it should include the user data as on the mockup. Make an API request to user API to get user info ([https://jsonplaceholder.typicode.com/users/1](https://jsonplaceholder.typicode.com/users/1))

## Bonus Points

- Use caching
- Use Rich domain model
- Add a diagram of the solution in Miro, attach screenshot in repository
- Cover solution classes with unit tests

❗ Please add instructions for setup if necessary

# Bonus Feature

Implement invitations management mechanics:

Event creator should be able to invite participants. Then, after approval, the invited user will become an event participant.

❗No need to implement user management endpoints like fetching all users. Assume frontend will work with users API and send you selected userIds.

### Invitations management

![Invitation Listing](<assets/image_4.png>)

![Received Invitation](<assets/image_5.png>)
