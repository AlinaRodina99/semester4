module WebDownloading

open System.IO
open System.Net
open System.Text.RegularExpressions

let regex = new Regex("<a href\s*=\s*\"?(http|https://[^\"]+)\"?\s*>")

/// Function that downloads url, prints count of symbols on page and returns it.
let fetchAsync url =
   async {
     try
       do printfn "Creating request for %s..." url
       let request = WebRequest.Create(url)
       use! response = request.AsyncGetResponse()
       do printfn "Getting response stream for %s..." url
       use stream = response.GetResponseStream()
       do printfn "Reading response for %s..." url
       use reader = new StreamReader(stream)
       let html = reader.ReadToEnd()
       do printfn "Read %d characters for %s..." html.Length url
       return Some html
     with
     | _ -> do printfn "This site is not available!"
            return None
  }

/// Function to get information about all links from start link.
let getAllLinks url =
    match (url |> fetchAsync |> Async.RunSynchronously) with
    | None -> []
    | Some value -> value |> regex.Matches |> Seq.map(fun x -> x.Groups.[1].Value |> fetchAsync)
                    |> Async.Parallel |> Async.RunSynchronously |> Seq.toList


