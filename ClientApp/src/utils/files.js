export const processFile = (fileBlob) => {
    const url = window.URL.createObjectURL(new Blob([fileBlob]));
    const link = document.createElement("a");
    link.href = url;
    link.setAttribute("download", `employees.xml`);
    document.body.appendChild(link);
    link.click();
    link.parentNode.removeChild(link);
  };