#!/bin/bash
set -e

host="$POSTGRES_HOST"
shift
cmd="$@"

until psql -h "$host" -U "$POSTGRES_USER" -c '\q'; do
  >&2 echo "Postgres is unavailable - sleeping"
  sleep 1
done

>&2 echo "Postgres is up - applying migrations"
dotnet ef database update

>&2 echo "Starting the application"
exec dotnet CategoryModule.dll
