# 'Front Loading' Variable Assignment

"Front loading" your function with `let`s or "variable assignment" is a simple way to make code more readble.

```javascript
function urlToString(url) {
  let result = url.base + url.path;

  if (url.queryParams) {
    result += queryParamsToStringg(url.queryParams);
  }
  if (url.fragment) {
    result += `#${url.fragment}`;
  }

  return result;
}
```

Refactored to:

```
function urlToString(url) {
  let { base, path } = url;
  let queryParams = queryParamsToString(url.queryParams);
  let fragment = url.fragment ? `#${url.fragment}` : '';

  return `${base}${path}${queryParams}${fragment}`;
}
```

Notice:
* We compute the strings an assign them to temporary values, then have a simple computation to combine them at the end. 
