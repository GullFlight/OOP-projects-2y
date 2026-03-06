using Itmo.ObjectOrientedProgramming.Lab2.UserItems;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivers;

public interface IMessageArchiver
{
    void Archive(Message message);
}