// namespace Itmo.ObjectOrientedProgramming.Lab4.Core;
//
// public class UnixPath : IUnixPath
// {
//     private readonly string _path;
//
//     public string? Path { get; private set; }
//
//     public UnixPath(string path)
//     {
//         _path = path;
//     }
//
//     public UnixPathResult Combine(string path1, string path2)
//     {
//         UnixPathResult checkFirst = CastToUnixPath(path1);
//         UnixPathResult checkSecond = CastToUnixPath(path2);
//         if (checkFirst is UnixPathResult.Success && checkSecond is UnixPathResult.Success)
//
//     }
//
//     public UnixPathResult CastToUnixPath(string path)
//     {
//         List<string> args = _path.Split('/', StringSplitOptions.RemoveEmptyEntries).ToList();
//         var unix = new List<string>();
//         foreach (string arg in args)
//         {
//             if (arg == ".") continue;
//             if (arg == "..")
//             {
//                 if (unix.Count == 0)
//                     return new UnixPathResult.Failure("not valid");
//             }
//
//             unix.Add(arg);
//         }
//
//         Path = "/" + string.Join("/", unix);
//         return new UnixPathResult.Success();
//     }
// }