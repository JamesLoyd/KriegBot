# KriegBot

![GitHub](https://img.shields.io/github/license/jamesloyd/kriegbot)

![GitHub pull requests](https://img.shields.io/github/issues-pr/jamesloyd/kriegbot)


## About
Kriegbot is a bot licensed under the MIT license. Originally written for Discord, this bot is now being targetted to also work with Slack.

Discord functionality is a bit broken and incompatible with slack's dealio. This will come at a later date.

## License
To see what you can do under the MIT License, you can check it out [here](https://github.com/JamesLoyd/KriegBot/blob/mainline/LICENSE).

## Environment Variables 
Environment variables are used to hide crucial tokens for Slack, Discord, and Github.

```
KRIEGBOT_SLACK_TOKEN="some token"
KRIEGBOT_GITHUB_TOKEN="some token"
```

## Structure
Kreig is split up into two parts

* API GateWay -> KriegBot.API
* Bot itself -> KriegBot.Slack, KriegBot.Discord

These talk to each other via a GRPC connection, this allows the API to handle incoming webhooks from integrations like github
The bot itself is generally setup to connect to each platform via one method. A list of the known types, planned and current are below.

#### Websocket
* Discord (planned for the future)
* Slack

#### API
* Slack (planned for the future)

## On Datastore's

Currently Krieg is setup to talk to SqlLite Databases, but there are plans in the future to split this out, so it will be truly datastore agnostic.
The author chose SqlLite because the bot generally sits behind a closed firewall and its easier to get it up and running. Arguments can be made for why this was a good idea or not.
But, the whole point of good architecture is to abstract the choice of datastore away, so you can focus more on how you respond to commands.

We use entity framework core to handle queries to the sql lite database. I have plans to make this easier to change out, so if you wanted to go the dapper route you can, but its not
a top priority of mine at the moment.

## On Contributions

If you notice anything that you would like to improve, you are free to branch off of mainline and open up a PR. This is entirely up to you.
As always, you can fork this, derive from this, use it as you see fit, all that is required is to abide by the MIT License. I make no extra demands past the license.