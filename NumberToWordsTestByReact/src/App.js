import React, { useState } from 'react';
import './App.css';
import { computeHeadingLevel } from '@testing-library/react';

function App() {
  const [number, setNumber] = useState('');
  const [result, setResult] = useState('');

  const handleInputChange = (event) => {
    setNumber(event.target.value);
  };

  const handleConvertClick = async () => {
    if (number === '') {
      alert('Please enter a number.');
      return;
    }

    try {
      const response = await fetch(`https://localhost:5001/api/NumberToWords?number=${number}`);
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      const data = await response.text();
      setResult(data); // Adjust based on the actual response structure
    } catch (error) {
      console.error('Error fetching data:', error);
    }
  };

  return (
    <div className="App">
      <header className="App-header">
        <p>
          <label htmlFor="number">INPUT NUMBER: </label>
          <input 
            type="number" 
            name="number" 
            id="number"
            style={{ width: '200px', height: '30px', fontSize: '16px'}} 
            value={number} 
            onChange={handleInputChange} 
          />
          <button 
            type="button" 
            className="btn"
            style={{ height: '33px', fontSize: '16px', marginLeft: '5px' }} 
            onClick={handleConvertClick}
          >
            Convert
          </button>
        </p>
        {result && <p>{result}</p>}
      </header>
    </div>
  );
}

export default App;
