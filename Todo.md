# TODO 
### Krieg specific
- ~~Setup GRPC~~
- Break modules up so they can be in thier own repos if necessary, current modules are too specific to my needs versus a more general approach. This should be fine for early development though.
  - Figure out dynamic loading of DLLS, this will make this easier
- Setup flow from grpc to modules
- Load module routing in based on name, so it will htit the right module


### Module : Devflow specific
- Handle Events for when PR's are raised and when reviews happen
- Inform users via slack DM that a PR is ready for review based on role
- Inform select users if a PR is ready for a demo
- setup commands, so it will add
  - reviewers
    - Devs who review code
  - leads
    - leads who review code, but can also get code merged in, if a demo isn't possible
  - developers
    - They actually write the code
  - QA
    - They review the functionality and are to be notified of demos
