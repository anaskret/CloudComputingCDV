const sql = require('mssql');
const parser = require('mssql-connection-string');

class PeopleDbContext {
    constructor(connectionString, log) {
        log("PeopleDbContext object has been created.");
        this.log = log;
        this.config = parser(connectionString);
        this.getPeople = this.getPeople.bind(this);
    }

    async getPeople() {
        this.log("getPeople function - run")
        const connection = await new sql.ConnectionPool(this.config).connect();
        const request = new sql.Request(connection);
        const result = await request.query('select * from People');
        this.log("getPeople function - done")
        return result.recordset;
    }

    async getPersonById(id){
        this.log("getPersonById function - run")
        const connection = await new sql.ConnectionPool(this.config).connect();
        const request = new sql.Request(connection);
        const result = await request.query(`select * from People where PersonId = ${id}`);
        this.log("getPeopleById function - done");
        return result.recordset;
    }

    async createPerson(person){
        this.log("createPerson function - run")
        const connection = await new sql.ConnectionPool(this.config).connect();
        const request = new sql.Request(connection);
        const result = await request.query(`insert into People values ('${person.firstName}', '${person.lastName}', '${person.phoneNumber}')`);
        this.log("createPerson function - done");
        return result.recordset;
    }
    
    async deletePerson(id){
        this.log("deletePerson function - run")
        const connection = await new sql.ConnectionPool(this.config).connect();
        const request = new sql.Request(connection);
        const result = await request.query(`delete from People where PersonId = ${id}`);
        this.log("deletePerson function - done");
        return result.recordset;
    }
}

module.exports = PeopleDbContext;