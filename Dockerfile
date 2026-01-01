# syntax=docker/dockerfile:1

################################################################################
# Build stage
################################################################################
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Copy source
COPY . /source
WORKDIR /source/src/Happy.Web

# Architecture passed by Docker (amd64 / arm64)
ARG TARGETARCH

# Restore & publish (safe for sh, multi-arch, buildx)
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish \
      -a $TARGETARCH \
      --use-current-runtime \
      --self-contained false \
      -o /app

################################################################################
# Runtime stage
################################################################################
FROM mcr.microsoft.com/dotnet/aspnet:9.0

WORKDIR /app

# Copy published output
COPY --from=build /app .

# Run as non-root user (provided by base image)
USER $APP_UID

ENTRYPOINT ["dotnet", "Happy.Web.dll"]
