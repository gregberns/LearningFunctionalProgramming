using System;
using System.Collections;
using System.Linq;
using LanguageExt;
using static LanguageExt.Prelude;
using Microsoft.Extensions.Configuration;

namespace SideEffectsAsValues
{
    public class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            ConConnectionInfo.CreateConnection(
                configuration.GetSection("CSS_HOSTNAME").Value,
                configuration.GetSection("CSS_USERNAME").Value,
                 configuration.GetSection("CSS_USERPASSWORD").Value,
                 configuration.GetSection("CSS_ACCOUNT").Value
            );
            
            

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
            UniCommand cmd = new UniCommand(); //us.CreateUniCommand();
            
            var ctx = new ExecContext(cmd);
                            //Can we pass in a parser to handle the response??
            var newCtx = ctx.Exec($"Command1")
                            .Exec("Query executed. 0 records found.", ParseHasZeroRecords)
                            .Exec($"Error Command2")
                            //This should not get executed
                            .Exec($"Command1");
            
            var cmds = newCtx.CommandsExecuted
                            .Reverse()
                            .AsEnumerable()
                            .Map((Either<ResponseException, Response> e) =>
                                match(e,
                                    Left: re => re.ToString(),
                                    Right: r => r.ToString())
                            );
            cmds.ToList().ForEach(i => Console.WriteLine(i));

        }
        public static Either<ResponseException, Response> ParseHasZeroRecords(Response resp) {
            return resp.ResponseMessage.Contains("0 records found.")
                ? Left<ResponseException, Response>(new ResponseException(
                    resp.Command,
                    new Exception("Parse Error: Command returned 0 records.")))
                : Right<ResponseException, Response>(resp);
        }

    }
    public static class ExecContextExtensions{
        public static ExecContext Exec(
            this ExecContext ctx, string statement) =>
                ctx.Exec(statement, r => Right(r));
        
        public static ExecContext Exec(
            this ExecContext ctx,
            string statement,
            Func<Response, Either<ResponseException, Response>> parse) {
                
            if (IsError(ctx.LastResponse())) return ctx;
            
            try {
                ctx.cmd.Command = statement;
                ctx.cmd.Execute();
                var res = new Response(new Command(statement), ctx.cmd.Response);
                var p = parse(res);
                return ctx.Push(p);
            } catch (Exception ex) {
                return ctx.Push(Left(new ResponseException(new Command(statement), ex)));
            }
        }

        public static bool IsError(Option<Either<ResponseException, Response>> opt) =>
            opt.Match(
                //If the last response was an error fall through
                Some: (Either<ResponseException, Response> e) => e.IsLeft,
                //But if there is no last response, then execute (because its the first time)
                None: () => false);
        
        
    }
    public class ExecContext {
        public UniCommand cmd;
        public readonly Stck<Either<ResponseException, Response>> CommandsExecuted;
        public ExecContext(UniCommand command){
            cmd = command;
            CommandsExecuted = new Stck<Either<ResponseException, Response>>();
        }
        private ExecContext(UniCommand command, Stck<Either<ResponseException, Response>> commands){
            this.cmd = command;
            this.CommandsExecuted = commands;
        }
        public ExecContext Push(Either<ResponseException, Response> response) =>
             new ExecContext(cmd, CommandsExecuted.Push(response));
        public Option<Either<ResponseException, Response>> LastResponse() => 
            CommandsExecuted.Peek(
                Some: x => Some(x),
                None: () => None);
    }

    public class Command : Record<Command> {
        public readonly string CommandStatement;
        public Command(string command){
            CommandStatement = command;
        }
        public override string ToString() =>
            CommandStatement;
    }
    public class Response : Record<Response> {
        public readonly Command Command;
        public readonly string ResponseMessage;
        public Response(Command command, string response){
            Command = command;
            ResponseMessage = response;
        }
        public override string ToString() =>
            $"Successful. Command: {this.Command.ToString()}; Reponse: {this.ResponseMessage}";
    }
    public class ResponseException : Record<ResponseException> {
        public readonly Command Command;
        public readonly Exception Exception;
        public ResponseException(Command command, Exception exception){
            Command = command;
            Exception = exception;
        }
        public override string ToString() =>
            $"Failed. Command: {this.Command}; Error: {Exception.Message}";
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


        public static ConConnection Connect(ConConnectionInfo connection) {
            
        }
    }
    public class ConConnectionInfo : Record<ConConnectionInfo> {
        public readonly string Host;
        public readonly string Username;
        public readonly string Password;
        public readonly string Account;
        public readonly string CssServiceType = "uvcs";
        private ConConnectionInfo(string host, string username, string password, string account){
            Host = host;
            Username = username;
            Password = password;
            Account = account;
        }
        public static Option<ConConnectionInfo> CreateConnection(string host, string username, string password){
            //Need to look at Validation instead of Option
            //Do some validation
            return new ConConnectionInfo(host, username, password, "concord");
        }
    }
    

    public class UniCommand {
        public string Command { get; set; }
        public string Response { get; set; }
        public void Execute() {
            //get command
            //exec command
            //set response
            if (Command.Contains("Error")) throw new Exception($"Command Error: {Command}");
            Response = $"Command Executed: {Command}";
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
