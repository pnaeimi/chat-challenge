# chat-challenge 
A simple Chat API using C#, .Net, and Entity Framework. Implements following end points:

### User
- Get list of users: [GET] api/users
- Get a specific user by user id: [GET] api/users/{userId}
- Register a new user: [POST] api/users
- Update user profile: [PUT] api/users/{userId} 
- Authenticate: Not implemented yet!!!!!

### Chat
- Get list of chats by user id: [GET] api/users/{userId}/chats
- Create a new chat: [POST] api/users/{userId}/chats

### Message
- Get list of messages by user id and chat id: [GET] api/users/{userId}/chats/{chatId}/messages
- Create a new message: [POST] api/users/{userId}/chats/{chatId}/messages
