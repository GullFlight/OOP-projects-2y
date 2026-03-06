using Itmo.ObjectOrientedProgramming.Lab2.UserItems;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public interface IRecipient
{
    void Receive(Message message);
}