namespace ConfigManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /*
    task stream of consciousness:

    check if config option exists in main or dev transform, if it is, it shouls also be int'other

    what we are checking for consistency:
    initially, config sections that use key value pair, such as connection strings and app settings
    worker role config & test project configs for ci at mo and oat
    this requires that we ensure that all the keys match between the worker role and the test projects

    we can't currently ensure consistency between tests and worker role for debug, as some run debug against worker role and some against individual handlers
    in theory, DEV should be worker role and DEBUG handlers, so if that was enforced/fixed we could check consistency for DEV/DEBUG

    we can't check consistency between the worker role and the handlers for debug, because they might be different, e.g. nsb transport
    although we could make sure all the handlers are self-consistent

    we don't care about consistency in config files for handlers for non-debug environments, e.g. AT as they are never used (only the worker role's config is important)

    load all config
    work with transformed config or base + transforms, probably base + transforms
    are all files xml?
    load worker role first as master? only relevant to xdomain
    dictionary of base + transforms
    load each in turn
    for every setting in each compare with master
    if setting in master check same, report if different, unless in exception list?
    if setting not in master do we add to master or not? flag to say create master, or stick with master. supply master in command line?

    probably need exceptions list to exclude some settings e.g. azure service bus in worker and msmq in handler

    how to work across solutions? do we want to? do xdomain first

    do we want to give same key name to settings that should be the same across solutions? or maintain list of those that should be the same
    would be better to give same name, and then can use different name if they should be different

    do we check for specific key values in specific sections? e.g appsettings, connectionstrings
    do we try and handle all sections? some sections probably should be different
    exact xml structure?

    whitelist/blacklist?

    we could have comment tag in (worker role) config to exclude setting from consistency check

    and in general use tags in config files as an option to building in intelligence into the tool

    automatically pick out handlers for consistency (debug, dev, debugci) - if debug and dev are set up consistently. best way to identify a handler? - we'll hit sql express vs localhost,  inconsistencies, so we may have to tidy them up (dev / debug) : either have a sql config & an express config, or everyone agree on 1

    automatically pick up tests (regex test in project name) for consistency with worker role for non-debug, e.g. at, ci, etc.
    */

    class Program
    {
        static void Main(string[] args)
        {
            // load worker role masters in (AT, CI, OAT, MO, PS, Release)

            // for all *test* projects
            // for all tranform configs in (AT, CI, OAT, MO, PS, Release)
                // load
                    // for each key value pair in (appsettings {key,value}, connectionstring {name,connectionstring}, servicemodel.client {contract.address})
                        // if key in master
                            // if value different error
                        // else
                            // warn (if requested in command line)
        }
    }
}
