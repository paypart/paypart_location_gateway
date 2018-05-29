using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using paypart_location_gateway.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading;

namespace paypart_location_gateway.Services
{
    public class Redis
    {
        IOptions<Settings> settings;
        IDistributedCache redis;
        public delegate void SetCountry(string key, Country country);
        public delegate void SetCountries(string key, IEnumerable<Country> countries);

        public delegate void SetState(string key, State state);
        public delegate void SetStates(string key, IEnumerable<State> states);

        public Redis(IOptions<Settings> _settings, IDistributedCache _redis)
        {
            settings = _settings;
            redis = _redis;
        }
        public async Task<Country> getcountry(string key, CancellationToken ctx)
        {
            Country countries = new Country();
            try
            {
                var country = await redis.GetStringAsync(key, ctx);
                countries = JsonHelper.fromJson<Country>(country);
            }
            catch (Exception)
            {

            }
            return countries;
        }

        public async Task<List<Country>> getcountries(string key, CancellationToken ctx)
        {
            List<Country> countries = new List<Country>();
            try
            {
                var country = await redis.GetStringAsync(key, ctx);
                countries = JsonHelper.fromJson<List<Country>>(country);
            }
            catch (Exception)
            {

            }
            return countries;
        }

        public async void setcountries(string key, Country countries)
        {
            try
            {
                var country = await redis.GetStringAsync(key);
                if (!string.IsNullOrEmpty(country))
                {
                    redis.Remove(key);
                }
                string value = JsonHelper.toJson(countries);

                await redis.SetStringAsync(key,value);
            }
            catch (Exception)
            {

            }

        }
        public async Task setcountriesAsync(string key, Country countries, CancellationToken cts)
        {
            try
            {
                var country = await redis.GetStringAsync(key);
                if (!string.IsNullOrEmpty(country))
                {
                    redis.Remove(key);
                }
                string value = JsonHelper.toJson(countries);

                await redis.SetStringAsync(key, value, cts);
            }
            catch (Exception ex)
            {

            }

        }
        public async Task setcountries(string key, List<Country> countries, CancellationToken cts)
        {
            try
            {
                var country = await redis.GetStringAsync(key);
                if (!string.IsNullOrEmpty(country))
                {
                    redis.Remove(key);
                }
                string value = JsonHelper.toJson(countries);

                await redis.SetStringAsync(key, value, cts);
            }
            catch (Exception)
            {

            }

        }


        public async Task<State> getstate(string key, CancellationToken ctx)
        {
            State states = new State();
            try
            {
                var state = await redis.GetStringAsync(key, ctx);
                states = JsonHelper.fromJson<State>(state);
            }
            catch (Exception)
            {

            }
            return states;
        }

        public async Task<List<State>> getstates(string key, CancellationToken ctx)
        {
            List<State> states = new List<State>();
            try
            {
                var state = await redis.GetStringAsync(key, ctx);
                states = JsonHelper.fromJson<List<State>>(state);
            }
            catch (Exception)
            {

            }
            return states;
        }

        public async void setstate(string key, State states)
        {
            try
            {
                var state = await redis.GetStringAsync(key);
                if (!string.IsNullOrEmpty(state))
                {
                    redis.Remove(key);
                }
                string value = JsonHelper.toJson(states);

                await redis.SetStringAsync(key, value);
            }
            catch (Exception)
            {

            }

        }
        public async Task setstateAsync(string key, State states, CancellationToken cts)
        {
            try
            {
                var state = await redis.GetStringAsync(key);
                if (!string.IsNullOrEmpty(state))
                {
                    redis.Remove(key);
                }
                string value = JsonHelper.toJson(states);

                await redis.SetStringAsync(key, value, cts);
            }
            catch (Exception ex)
            {

            }

        }
        public async Task setstates(string key, List<State> states, CancellationToken cts)
        {
            try
            {
                var state = await redis.GetStringAsync(key);
                if (!string.IsNullOrEmpty(state))
                {
                    redis.Remove(key);
                }
                string value = JsonHelper.toJson(states);

                await redis.SetStringAsync(key, value, cts);
            }
            catch (Exception)
            {

            }

        }
    }
}
