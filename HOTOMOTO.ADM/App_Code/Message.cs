using System;
using System.Runtime.Serialization;

[Serializable()]
public class Message : ISerializable {
    int _id;
    string _text;
    DateTime _date;

    public Message(int id, string text, DateTime date) {
        this._id = id;
        this._text = text;
        this._date = date;
    }

    public Message(SerializationInfo info, StreamingContext ctxt) {
        this._id = (int)info.GetValue("MessageID", typeof(int));
        this._text = (String)info.GetValue("Text", typeof(string));
        this._date = (DateTime)info.GetValue("CreateDate", typeof(DateTime));
    }

    public void GetObjectData(SerializationInfo info, StreamingContext ctxt) {
        info.AddValue("MessageID", this._id);
        info.AddValue("Text", this._text);
        info.AddValue("CreateDate", this._date);
    }

    public int MessageID {
        get { return this._id; }
    }

    public string Text {
        get { return this._text; }
    }

    public DateTime CreateDate {
        get { return this._date; }
    }
}
