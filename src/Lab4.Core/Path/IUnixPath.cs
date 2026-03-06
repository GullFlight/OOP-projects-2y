namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public interface IUnixPath
{
    UnixPathResult Combine(string path1, string path2);

    UnixPathResult CastToUnixPath(string path);
}