import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { ContactsService } from './generated/services/ContactsService'
import type { Contacts } from './generated/models/ContactsModel'
import type { Payment } from './generated/models/PaymentModel'
import { PaymentService } from './generated'

function App() {
  const [count, setCount] = useState(0)
  const [contacts, setContacts] = useState<Contacts[]>([])
  const [dvLoading, setDvLoading] = useState(false)
  const [dvError, setDvError] = useState<string | null>(null)
  const [payments, setPayments] = useState<Payment[]>([])
  const [sqlLoading, setSqlLoading] = useState(false)
  const [sqlError, setSqlError] = useState<string | null>(null)

  const getDataverseData = async () => {
    try {
      setDvLoading(true)
      setDvError(null)
      const result = await ContactsService.getAll(); 
      if (result.data) {
        console.log('Contacts retrieved:', result.data);
        setContacts(result.data)
      } else {
        console.log('No contacts found.');
        setContacts([])
      }
    } catch (err) {
        const errorMessage = 'Failed to retrieve contacts: ' + (err as Error).message
        console.error(errorMessage, err);
        setDvError(errorMessage)
    } finally {
        setDvLoading(false)
    }
  }
  
  const getSqlData = async () => {
    try {
      setSqlLoading(true)
      setSqlError(null)
      const result = await PaymentService.getAll(); 
      if (result.data) {
        console.log('Payments retrieved:', result.data);
        setPayments(result.data)
      } else {
        console.log('No payments found.');
        setPayments([])
      }
    } catch (err) {
        const errorMessage = 'Failed to retrieve payments: ' + (err as Error).message
        console.error(errorMessage, err);
        setSqlError(errorMessage)
    } finally {
        setSqlLoading(false)
    }
  }

  return (
    <>
      <div>
        <a href="https://vite.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Power SDK Dataverse & SQL Connection (local)</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <button onClick={getDataverseData} disabled={dvLoading} style={{ marginLeft: '10px' }}>
          {dvLoading ? 'Loading...' : 'Load Contacts'}
        </button>
        <button onClick={getSqlData} disabled={sqlLoading} style={{ marginLeft: '10px' }}>
          {sqlLoading ? 'Loading...' : 'Load Payments'}
        </button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>

      {dvError && (
        <div style={{ color: 'red', margin: '10px 0' }}>
          Error: {dvError}
        </div>
      )}

      {contacts.length > 0 && (
        <div style={{ margin: '20px 0' }}>
          <h3>Dataverse Contacts ({contacts.length})</h3>
          <ul style={{ textAlign: 'left', maxHeight: '200px', overflow: 'auto' }}>
            {contacts.map((contact, index) => (
              <li key={contact.contactid || index}>
                {contact.fullname || 'No name'} - {contact.emailaddress1 || 'No email'}
              </li>
            ))}
          </ul>
        </div>
      )}

      {sqlError && (
        <div style={{ color: 'red', margin: '10px 0' }}>
          Error: {sqlError}
        </div>
      )}

      {payments.length > 0 && (
        <div style={{ margin: '20px 0' }}>
          <h3>Payments ({payments.length})</h3>
          <ul style={{ textAlign: 'left', maxHeight: '200px', overflow: 'auto' }}>
            {payments.map((payment, index) => (
              <li key={payment.payment_id|| index}>
                {payment.user_name || 'No name'} - {payment.amount || 'No amount'}
              </li>
            ))}
          </ul>
        </div>
      )}

    </>
  )
}

export default App
