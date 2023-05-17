# Overview
Web based API to perform a search/match of each coordinate passed as input based
on established sets of rectangles.

# Basic Requirements
- Contains data seed methods to populate 200 rectangle data entries into database
- Each data entry (and therefore row(s)) must define rectangle coordinates and/or
dimensions, upon your choice of design
- Define an endpoint that takes an array of coordinates upon your choice of design of
input object
- For each passed coordinate, output a list of rectangles defined in database that this
coordinate falls into

# Bonus Points
- Implement automated tests using tools of your choice.
- Database makes use of indexes and foreign keys.
- Implement basic authentication of the caller of API.
- Any further design considerations assuming scaling this system and integrations with
external consumers.
- Wrap the executable(s) into Docker container.

# Testing
The api/rectangles endpoints requires authentication.
You can get authentication token using the /api/account/login endpoint with the following credentials:

``` json
{
  "userName": "admin",
  "password": "Qwerty@123"
}
```

Then use returned token in the Authorization: Bearer <token> header.
