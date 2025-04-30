# Home Dine API

- [Home Dine API](#home-dine-api)
    - [Auth](#auth)
        - [Register](#register)
            - [Register Request](#register-request)
            - [Register Response](#register-response)
        - [Login](#login)
            - [Login Request](#login-request)
            - [Login Response](#login-response)


## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName": "John",
    "lastName": "Doe",
    "email": "johndoe@example.com",
    "password": "Password123!"
}
```

#### Register Response

```js
200 OK
```

```json
{
    "id": "3720c0a4-35f3-46ee-93d8-16db9db4cff1",
    "firstName": "John",
    "lastName": "Doe",
    "email": "johndoe@example.com",
    "token": "eyJhbGci....adQssw5c"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
    "email": "johndoe@example.com",
    "password": "Password123!"
}
```
#### Login Response

```js
200 OK
```

```json
{
    "id": "3720c0a4-35f3-46ee-93d8-16db9db4cff1",
    "firstName": "John",
    "lastName": "Doe",
    "email": "johndoe@example.com",
    "token": "eyJhbGci....adQssw5c"
}
```
