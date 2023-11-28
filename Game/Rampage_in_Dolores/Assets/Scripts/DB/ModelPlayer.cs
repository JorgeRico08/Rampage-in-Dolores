using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections;
using System.Collections.Generic;

public class ModelPlayer
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("Nickname")]
    public string Nickname { get; set; }

    [BsonElement("Password")]
    public string Password { get; set; }

    [BsonElement("Score")]
    public int Score { get; set; }
}