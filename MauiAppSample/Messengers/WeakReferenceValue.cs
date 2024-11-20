using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiAppSample.Messengers;

public class WeakReferenceValueMessage : ValueChangedMessage<string>
{
    public WeakReferenceValueMessage(string value) : base(value)
    {
    }
}
