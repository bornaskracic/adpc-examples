The following examples serve as a recap of SQL functionlities.

First, verify that Docker is installed on your machine. If not, make sure to install it.
Then, create a Postgres container:
```bash
docker run -d \
    --name postgres-local \
    -p 5432:5432
    -e POSTGRES_PASSWORD=mysecretpassword \
    postgres​:18
```
Docker will make `postgres-local` the name of the container (otherwise it will assign a random name). Flag `-p` defines port binding between host and container port. 5432 is default Postgres port that is bound by Postmaster. -e defines the envirnoment variable value (`key=value`) that will be used to configure the Postgres instance. 

**NOTE: Postgres image requires setting the `POSTGRES_PASSWORD` environment variable to non-empty string.**

If you want to verify that the container is running, it needs to be visible in the output of this command:
```bash
docker ps
```

Now you can use the IDE of your choice to connect to the database instance - Visual Studio, VS Code (with Postgresql extension), DataGrip, DBeaver, etc. If you want to interact with the Postgres intance immediately, you can 'execute into container' with the following command:
```bash
docker exec -it postgres-local psql -U postgres
```
Using `-it` flag allows Docker to use `psql` utility as a REPL (read-evaluate-print loop) which will continously prompt the user to input command, process it, print the output and then prompt again, until the program is terminated.

To seed the database, you can use the `_setup.sq;` script provided in this directory. To execute the content of the script, you can copy it to the Docker container:
```bash
docker cp _setup.sql postgres-local:/seed.sql
```
(Make sure to use the appropriate local file path when copying into the container)
Then you can execute it using `exec`:
```bash
docker exec postgres-local psql -U postgres -f seed.sql
```
Note: In this example, we don't actually need the `-it` flag as `psql` was used to execute a single file (it will not enter REPL mode).

# Examples

To work through the examples, you need to run a Postgres container on your machine, using the aforementioned steps.

## Example 1
Retrieve different information from the following system tables:
- pg_database​
- pg_stat_database​
- pg_stats​
- pg_stat_user_tables​
- pg_stat_activity​
- information_schema.tables​

Discuss the results you retrieve from the tables and try to filter out the information you are interested in.

## Example 2
Print all database information using SQL queries with following tables:
- pg_database
    - oid
    - datname​
- pg_stat_database​ 
    - xact_commit​
    - xact_rollback

## Example 3
Using _setup.sql script (present in `Session01_Recap` and also uploaded on IE), setup the mock database.
Retrieve the following information:
- A) top 5 students by average points
- B) most popular exams (by applications)
- C) pass rate (in percentages)

## Example 4
Insert data about two students within a transaction, but make a mistake during the second insertion (e.g., duplicate primary key) and show that the transaction has been rolled back.

## Example 5
Using raw database connection and language of your choice (C# in these examples, as well as `Npgsql` Postgres driver for C#), in the program code do the following:
- A) enter a new student and print the assigned ID
- B) update scores and status of a student's exam application
- C) using a transaction, delete one student and their exam registrations
- D) retrieve student data and map it to instances of the Student program class (try to write a method that could map row data to instance of any appropriate mapper class)
