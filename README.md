# ZendeskImporter

A quick & dirty incremental importer from Zendesk into SQL Server. Gets tickets (including stats & comments but excluding attachments), organizations, and contacts.

Set up the database by pointing Redgate SQL Compare at the Database folder as a source. Populate the db connection string & Zendesk account details in `app.config`. Run the executable. Leave at least 5 minutes between runs, in line with Zendesk's rate-limit requiremenets. To build, requires the ZendeskApi_v2 package version at least 3.8.1-alpha11 (adding support for Organization bulk exports), which as of time of writing is only available by adding https://www.myget.org/F/zendeskapi_v2_prerelease/api/v3/index.json to your NuGet sources.

Though this may be a useful starting point, it was quickly put together for a specific personal need so lacks important things including good error handling / recoverability, tests, more accurate rate limiting.
