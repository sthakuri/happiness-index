#!/bin/sh
set -e

echo "Starting MongoDB JSON restore..."

mongoimport \
  --db Happy \
  --collection SFNeighborhood \
  --file /docker-entrypoint-initdb.d/Happy.SFNeighborhood.json \
  --jsonArray

echo "MongoDB restore completed."
