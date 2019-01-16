using System;
using System.Collections.Generic;
using System.Linq;

namespace IsAnAntipattern.Services
{
    internal class SourceData
    {
        public static IEnumerable<string[]> Lines => Source.Select(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries));
        
        private static readonly string[] Source =
        {
            "Lately it's become fashionable to create repositories that delegate to {thing} in an attempt to decouple the consuming code, while still getting some of the other {thing} productivity benefits.",
            "This breaks down really badly when you need to work with relationships.",
            "This is fundamental to how {thing} works.",
            "This is a fundamentally flawed, leaky abstraction.",
            "For this reason alone, I consider an {thing}-backed repository to be the worst of both worlds, not a convenient middleground.",
            "The user initiates a navigation, and the browser gets busy: it'll likely have to resolve a dozen DNS names, establish an even larger number of connections, and then dispatch one or more requests over each.",
            "In turn, for each request, it often does not know the response size (chunked transfers), and even when it does, it is still unable to reliably predict the download time due to variable network weather, server processing times, and so on.",
            "Finally, fetching and processing one resource might trigger an entire subtree of new requests.",
            "Ok, so loading a page is complicated business, so what?",
            "Well, if there is no way to reliably predict how long the load might take, then why do so many browsers still use and show the {thing}?",
            "At best, the {thing} is a lie that misleads the user; worse, the success criteria is forcing developers to optimize for 'onload time', which misses the progressive rendering experience that modern applications are aiming to deliver.",
            "{thing}s fail both the users and the developers; we can and should do better.",
            "{thing} is, as Arbuthnot Fink calls it, our industry’s Grand Failure.",
            "A good domain model is not a data model.",
            "A domain model describes behaviour, and the data is an artefact of that.",
            "We have deluded our users, and ourselves, that applications are nothing more than a thin layer around our database.",
            "TL;DR {thing} is a terrible anti-pattern that violates all principles of object-oriented programming, tearing objects apart and turning them into dumb and passive data bags.",
            "There is no excuse for {thing} existence in any application, be it a small web app or an enterprise-size system with thousands of tables and CRUD manipulations on them.",
            "It’s a standard de-facto and still I’m saying that it’s wrong? Yes.",
            "I’m claiming that the entire idea behind {thing} is wrong.",
            "Its invention was maybe the second big mistake in OOP after NULL reference.",
            "However, my argument is different than what they’re saying.",
            "Even though their reasons are practical and valid, like “{thing} is slow” or “database upgrades are hard,” they miss the main point.",
            "Because of this terrible and offensive violation of the object-oriented paradigm, we have a lot of practical issues already mentioned in respected publications.",
            "I can only add a few more.",
            "When some object is working with a list of posts, it needs to deal with an instance of SessionFactory.",
            "How can we mock this dependency?",
            "We have to create a mock of it?",
            "How complex is this task?",
            "Look at the code above, and you will realize how verbose and cumbersome that unit test will be.",
            "Again, let me reiterate.",
            "Practical problems of {thing} are just consequences.",
            "The fundamental drawback is that {thing} tears objects apart, terribly and offensively violating the very idea of what an object is.",
            " {thing} is a well-known pattern, and since it was described by Martin Fowler, it must be good, right?",
            "No, it's actually an anti-pattern and should be avoided. ",
            "Let's examine why this is so.",
            "In short, the problem with {thing} is that it hides a class' dependencies, causing run-time errors instead of compile-time errors, as well as making the code more difficult to maintain because it becomes unclear when you would be introducing a breaking change. ",
            "While this use of {thing} is problematic from the consumer's point of view, what seems easy soon becomes an issue for the maintenance developer as well. ",
            " Was this a breaking change?",
            "This can be surprisingly hard to answer.",
            "It certainly compiled fine, but broke one of my unit tests.",
            "What happens in a production application?",
            "The bottom line is that it becomes a lot harder to tell whether you are introducing a breaking change or not.",
            "You need to understand the entire application in which the {thing} is being used, and the compiler is not going to help you. ",
            "The problem with using a {thing} isn't that you take a dependency on a particular {thing} implementation (although that may be a problem as well), but that it's a bona-fide anti-pattern.",
            "It will give consumers of your API a horrible developer experience, and it will make your life as a maintenance developer worse because you will need to use considerable amounts of brain power to grasp the implications of every change you make. ",
            "There’s a horrible disease out there, and a lot of programmers – both junior and senior – are affected by it: {thing}itis.",
            "Please, let’s help stopping the plague from spreading further by reading and understanding this post.",
            "What is {thing}itis?",
            "It is something that’s both bad for your code’s health, and bad for your own and your co-workers sanity.",
            "We will get to simple, easy-to-understand examples and counter-examples of {thing}itis gone bad in a minute.",
            "When I talk about {thing}itis, I’m speaking of codebases that are so heavily infected with {thing}s, that their count is already in the high twenties – if you’re working on such a thing, I feel sorry for you.",
            "If you’re an experienced developer and teach inexperienced programmers how to put in even more of the damn things without giving them an alternative, go and hide in a corner, now!",
            "So why are {thing}s bad, exactly?",
            "Rather than coming up with things that have already been said elsewhere, I’d like to give concrete examples of where a {thing} was clearly the wrong choice, and what the alternatives would have been.",
            "As much as possible, do not use {thing} at all.",
            "According to this comment, {thing} should never have been in the library in the first place.",
            "It seems that if Flux was introduced in conjunction with React initially, {thing} would not even exist.",
            "It seems that {thing} was used to allow react to function by itself without flux.",
            "If a React component must have side-effects, it must use Flux actions instead of having {thing}.",
            "Components ideally should have no {thing} at all.",
        };
    }
}