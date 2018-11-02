using System;
using LanguageExt;
using static LanguageExt.Prelude;

namespace SideEffectsAsValues
{
    public class Program
    {
        static void Main(string[] args)
        {
            new DoStuff().Do();
            Console.WriteLine("Done.");
        }

        void Somthing(){

            // UniSession us = UniObjects.OpenSession(lHostName, lUser, lPassword, lAccount, lServiceType);

            // UniCommand cmd = us.CreateUniCommand();
            // cmd.Command = $"SELECT {indexFile} WITH DEV.CODE = \"{developerCode}\"";
            // cmd.Execute();
            // result.Results.Add(new CommandResponse(cmd.Command, cmd.Response));

            // cmd.Command = $"QSELECT {indexFile}";
            // cmd.Execute();
            // result.Results.Add(new CommandResponse(cmd.Command, cmd.Response));

            // cmd.Command = filterCriteria;
            // cmd.Execute();
            // result.Results.Add(new CommandResponse(cmd.Command, cmd.Response));

            // cmd.Command = $"SAVE-LIST {saveListName}";
            // cmd.Execute();
            // result.Results.Add(new CommandResponse(cmd.Command, cmd.Response));

        }

        
    }

    public class DoStuff {
        public void Do(){
            //var connectionInfo = new ConConnectionInfo("host", "user", "password");
            // ConConnection.Connect(connectionInfo)
            //     .bind()

            // CommandContext<string>.New("Hello")
            //     .Bind((s) => CommandContext<string>.New(s + " World!"))
            //     .Bind((s) => CommandContext<string>.New(s + " Is New"))
            //     .Print();

            //UniSession us = UniObjects.OpenSession(lHostName, lUser, lPassword, lAccount, lServiceType);
            UniCommand cmd = null; //us.CreateUniCommand();
            
            var indexFile = "";
            var developerCode = "";

            var ctx = new ExecContext(cmd);
            var eResp = ctx.Exec($"SELECT {indexFile} WITH DEV.CODE = \"{developerCode}\"");
            

        }

        public void Check(Either<ResponseException, Response> response){
            //might need a enclosure that has a 'LastResponse'
            //response.Bind(rite => )
        }
    }
    public static class ExecContextExtensions{
        public static ExecContext Exec(this ExecContext ctx, string statement) {
                try {
                    ctx.cmd.Command = statement;
                    ctx.cmd.Execute();
                    return ctx.Append(Right(new Response(new Command(statement), ctx.cmd.Response)));
                } catch (Exception ex) {
                    return ctx.Append(Left(new ResponseException(new Command(statement), ex)));
                }
        }
    }
    public class ExecContext {
        public UniCommand cmd;
        public readonly Lst<Either<ResponseException, Response>> CommandsExecuted;
        public ExecContext(UniCommand command){
            cmd = command;
            CommandsExecuted = new Lst<Either<ResponseException, Response>>();
        }
        private ExecContext(UniCommand command, Lst<Either<ResponseException, Response>> commands){
            this.cmd = command;
            this.CommandsExecuted = commands;
        }
        public ExecContext Append(Either<ResponseException, Response> response) {
            return new ExecContext(cmd, CommandsExecuted.Add(response));
        }
    }

    public class Command : Record<Command> {
        public readonly string CommandStatement;
        public Command(string command){
            CommandStatement = command;
        }
    }
    public class Response : Record<Response> {
        //command and response string
        public readonly Command Command;
        public readonly string ResponseMessage;
        public Response(Command command, string response){
            Command = command;
            ResponseMessage = response;
        }
    }
    public class ResponseException : Record<ResponseException> {
        //command and response string
        public readonly Command Command;
        public readonly Exception Exception;
        public ResponseException(Command command, Exception exception){
            Command = command;
            Exception = exception;
        }
    }

    //take a command
    //command will be executed
    //result comes back and gets added to context
    //another command can be executed
    // public static class CommandContextExtensions {
    //     //bind :: (a -> mb) -> ma -> mb
    //     public static CommandContext<T> Bind<S, T>(this CommandContext<S, T> ctx, Func<S, CommandContext<T>> f) {
    //         return CommandContext<S, T>.New(s => {
    //             var t = ctx.Run(s);
    //             return f(t);
    //             //ctx.Run((S s) => f(s)
    //         });
    //     }
    //     public static void Print<S>(this CommandContext<S> ctx){
    //         ctx.Run(s => {
    //                 Console.WriteLine(s);
    //                 return CommandContext<string>.New(null);
    //             });
    //     }
    // }
    // public class CommandContext<S, T> {
    //     private Func<S, T> f;
    //     //store the connection?
    //     private CommandContext(Func<S, T> f) {
    //         this.f = f;
    //     }
    //     public static CommandContext<S, T> New<S, T>(Func<S, T> f){
    //         return new CommandContext<S, T>(f);
    //     }
    //     public CommandContext<T> Run<T>(Func<S, CommandContext<T>> f) {
    //         return CommandContext<T>.New(s => f(this.f(s)));
    //     }
    // }
    
    public class ConConnection {
        // getArgs :: IO (List Chars)
        // putStrLn :: Chars -> IO ()
        // readFile :: FilePath -> IO Chars
        // lines :: Chars -> List Chars
        // void :: IO a -> IO ()

        // execCommand :: Command -> CommandMonad<CommandResult>


        // public static ConConnection Connect(ConConnectionInfo connection) {
        //     return ConConnection();
        // }
    }
    public class ConConnectionInfo : Record<ConConnectionInfo> {
        public readonly string Host;
        public readonly string Username;
        public readonly string Password;
        public ConConnectionInfo(string host, string username, string password){
            Host = host;
            Username = username;
            Password = password;
        }
        
    }
    

    public class UniCommand {
        public string Command { get; set; }
        public string Response { get; set; }
        public void Execute() {
            //get command
            //exec command
            //set response
        }
    }
    public class UniObjects{
        public static UniSession OpenSession(string host, string username, string password, string account, string serviceType){
            return new UniSession();            
        }
    }

    public class UniSession{
        public UniCommand CreateUniCommand() {
            return new UniCommand();
        }
    }


}
