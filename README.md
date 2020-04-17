# SASSHA API

This repo contains models for the SASSHA API and a couple of example apps.

## Compilation

All code should compile with VS >= 2015.  Nuget packages are required for extensions to
the Http client for methods such as `HttpResponseMessage.Content.ReadAsAsync<DTO>()`

## Usage

DonkeyExampleApp expects a json config file.  It will accept a path to the config file
given as a commandline argument or dragged and dropped onto the exe.  Failing that, it
will look for DefaultConfig.json in the same directory as the exe.

## An example config json file:

```json
{
	"apiUrl": "https://your.domain.com/application/",
	"apiKey": "YOUR_API_KEY",
	"contractorCode": "EXAMPLE_BOILER_CO",
	"lastPoll": "2020-04-16"
}

