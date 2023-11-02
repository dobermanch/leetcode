#!/bin/bash
# Updates Tags sections in the README.md file
# Example: Tags: Array, Hash Table   --> Tags: `Array` `Hash Table`  

shopt -s extglob

file_path="README.md"

prefixMatch="Tags"

# The regex pattern
pattern="(^$prefixMatch:.*$)"

# Extract the regex group
groups=$(sed -nE "s/$pattern/\1/p" "$file_path")
IFS=$'\n' read -rd '' -a groups <<< "$groups"

for group in "${groups[@]}"; do
    # Split string by specified separators into an array
    IFS=',\`:' read -ra rawParts <<< "$group"

    # Cleanup and prepare parts
    parts=()
    for part in "${rawParts[@]}"; do
        # Remove the trailing and leading spaces
        part=("${part/#*( )/}") 
        part=("${part/%*( )/}") 
        
        if [[ -z "$part" || "$part" = "$prefixMatch" ]]; then
            continue
        fi

        parts+=("\`$part\`")
    done
    
    # Format final string
    formatted="$prefixMatch: $(printf "%s " "${parts[@]}") "

    # Escape characters for sed command
    group="$(echo $group | sed -e 's/[]\/$*.^|()[]/\\&/g')"
    formatted="$(echo $formatted | sed -e 's/[]\/$*.^()[]/\\&/g')"

    # Replace original match with modified
    sed -i -E "s/$group/$formatted/g" "$file_path"
done
