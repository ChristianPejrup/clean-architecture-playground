{
  "x-generator": "NSwag v13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))",
  "swagger": "2.0",
  "info": {
    "title": "My Title",
    "version": "1.0.0"
  },
  "consumes": [
    "application/json"
  ],
  "produces": [
    "application/json"
  ],
  "paths": {
    "/api/v1.0/Accounts/{id}": {
      "get": {
        "tags": [
          "Accounts"
        ],
        "operationId": "Accounts_Get",
        "parameters": [
          {
            "type": "string",
            "name": "id",
            "in": "path",
            "required": true,
            "format": "guid",
            "x-nullable": false
          }
        ],
        "responses": {
          "200": {
            "x-nullable": true,
            "description": "",
            "schema": {
              "$ref": "#/definitions/AccountDto"
            }
          }
        }
      }
    }
  },
  "definitions": {
    "AccountDto": {
      "type": "object",
      "required": [
        "Id",
        "Email"
      ],
      "properties": {
        "Id": {
          "type": "string",
          "format": "guid"
        },
        "Email": {
          "type": "string"
        }
      }
    }
  }
}