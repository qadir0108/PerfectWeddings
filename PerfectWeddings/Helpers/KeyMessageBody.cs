namespace System
{
    [Serializable]
    public struct KeyMessageBody<TKey, TMessage, TPayload>
    {
        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.KeyMessageBody<TKey, TMessage, TPayload>
        //     structure with the specified key, message and payload.
        //
        // Parameters:
        //   key:
        //     The object defined in each key/message/payload KeyMessageBody.
        //
        //   message:
        //     The definition associated with message.
        //
        //  payload:
        //      The definition associated with payload.
        //
        public KeyMessageBody(TKey key, TMessage message, TPayload payload)
            : this()
        {
            Key = key;
            Message = message;
            Payload = payload;
        }

        // Summary:
        //     Gets the key in the key/message/payload KeyMessageBody.
        //
        // Returns:
        //     A TKey that is the key of the System.Collections.Generic.KeyMessageBody<TKey, TMessage, TPayload>.
        public TKey Key { get; set; }
        //
        // Summary:
        //     Gets the message in the key/message/payload KeyMessageBody.
        //
        // Returns:
        //     A TMessage that is the message of the System.Collections.Generic.KeyMessageBody<TKey, TMessage, TPayload>.
        public TMessage Message { get; set; }

        //
        // Summary:
        //     Gets the data in the key/message/payload KeyMessageBody.
        //
        // Returns:
        //     A TPayload that is the payload of the System.Collections.Generic.KeyMessageBody<TKey, TMessage, TPayload>.
        public TPayload Payload { get; set; }
    }
}