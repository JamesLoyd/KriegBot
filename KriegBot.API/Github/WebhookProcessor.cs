using Octokit.Webhooks;
using Octokit.Webhooks.Events;
using Octokit.Webhooks.Events.PullRequest;

namespace KriegBot.API.Github;

public sealed class WebhookProcessor : WebhookEventProcessor
{
    protected override Task ProcessPullRequestWebhookAsync(WebhookHeaders headers, PullRequestEvent pullRequestEvent, PullRequestAction action)
    {
        return Task.Run(() => { Console.WriteLine(
            $"Hello there, this event was raised by {pullRequestEvent.Sender.Name} username? {pullRequestEvent.Sender.Login} action? {action}"); });
    }
}