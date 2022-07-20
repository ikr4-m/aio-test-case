# General Description

- Dantzig joins all Slack channel
His keyboard is broken, he can only mention @channel
- Given a map of channel name and its member’s ID, e.g. {"general": [2, 3, 4], "infra": [3, 5], "humor": [4, 6]}
- The member's ID may not be sorted

## Level 1
- Dantzig wants to notify person X and also minimize noise to other persons in that room
- Which room should Dantzig go to?

## Level 2
- Dantzig notices that some channels contains exactly the same members, he wish to merged those channels.
- Help Dantzig to recognize those channels, return list of list (output order doesn’t matter)

input: {"general": [2, 3, 4], "infra": [3, 5], "humor": [4, 6]}
output: {"general": [2, 3, 4], "infra": [3, 5], "humor": [4, 6]}

input: {"general": [3, 5], "infra": [3, 5], "humor": [4, 6]}
output: {"general-infral": [3, 5], "humor": [4, 6]}
