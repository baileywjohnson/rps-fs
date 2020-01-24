open System

[<EntryPoint>]
let main (args : string[]) =
    let mutable gameLoop = true;
    let mutable userSelection = 0;
    let mutable cpuSelection = 0;
    let rand = System.Random()

    //Parse User Input Function
    let rec queryAnInt () =
        printf "Input: " 
        let input = System.Console.ReadLine()
        match System.Int32.TryParse input with
        | (true, number) -> printfn "-------"
                            number
        | _              -> printfn "Please Enter a Number"
                            queryAnInt ()

    //Check to Make Sure No Command Line Arguments Passed (For Now)
    if args. Length <> 0 then
        failwith "RockPaperScissors.exe takes no arguments."

    //Welcome Message
    printfn "Welcome to Rock, Paper, Scissors in F#!"
    printfn "---------------------------------------\n"

    //Start Game Loop
    while gameLoop do
        printfn "What'll it be?\n1) Rock\n2) Paper\n3) Scissors\n4) Exit\n"
        userSelection <- queryAnInt();
        cpuSelection <- rand.Next(1,4);

        //Determine Winner
        if userSelection = 1 || userSelection = 2 || userSelection = 3 then
            printfn "You: %d\nCPU: %d\n" userSelection cpuSelection

            //Tie Condition
            if userSelection = cpuSelection then
                printfn "It's a Draw!\n-------\n"
            elif abs (userSelection - cpuSelection) = 1 then
                if userSelection > cpuSelection then
                    printfn "You Win!\n-------\n"
                else
                    printfn "CPU Wins!\n-------\n"
            else
                if userSelection > cpuSelection then
                    printfn "CPU Wins!\n-------\n"
                else
                    printfn "You Win!\n-------\n"

        //Exit Condition
        elif userSelection = 4 then
            gameLoop <- false

        //Input Validation
        else
            printfn "Invalid Input, Try Again\n"

    //Keep Console Open
    printfn "Thanks for Playing, Press Any Key to Exit..."
    System.Console.ReadKey() |> ignore
    0
