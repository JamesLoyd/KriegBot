using Octokit.Webhooks;
using Octokit.Webhooks.Events;
using Octokit.Webhooks.Events.PullRequest;

namespace KriegBot.API.Github;

public sealed class WebhookProcessor : WebhookEventProcessor
{
    protected override Task ProcessPullRequestWebhookAsync(WebhookHeaders headers, PullRequestEvent pullRequestEvent, PullRequestAction action)
    {
        switch (action)
        {
            case PullRequestActionValue.Opened:
                Console.WriteLine("PR Opened");
                break;
            case PullRequestActionValue.ReadyForReview:
                Console. WriteLine("Ready for review");
                break;
            case PullRequestActionValue.Reopened:
                Console.WriteLine("Reopened");
                break;
            case PullRequestActionValue.Synchronize:
                Console.WriteLine("Synchronized");
                break;
            default:
                Console.WriteLine("Some other action");
                break;
        }

        return Task.Run(() => { Console.WriteLine(
            $"Hello there, this event was raised by {pullRequestEvent.PullRequest.RequestedReviewers} username? {pullRequestEvent.Sender.Login} action? {Newtonsoft.Json.JsonConvert.SerializeObject(pullRequestEvent)}"); });
    }
}